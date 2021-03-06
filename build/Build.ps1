param([Switch]$Rebuild)

if ( $env:APPVEYOR -eq "True" )
{
	[string]$builder = "MSBuild.exe"
	[string]$winBuilder = "MSBuild.exe"
	[string]$nuget = "nuget"
	[string]$nugetVerbosity = "quiet"
	[string]$dotnetVerbosity = "Warning"
	
	# AppVeyor should have right MSBuild and dotnet-cli...
	# Android SDK should be installed in init and ANDROID_HOME should be initialized before this script.
}
else
{
	# Ensure Android SDK for API level 10 is installed.
	# Thanks to https://github.com/googlesamples/android-ndk/pull/80

	[string]$env:ANDROID_HOME = "$env:localappdata/Android/android-sdk/"

	if ( !( Test-Path "$env:ANDROID_HOME/tools/android.bat" ) )
	{
		Write-Error "Android SDK is required."
		exit 1
	}

	./SetBuildEnv.ps1
	if ( $env:SKIP_ANDROID_SDK_UPDATE -ne "True" )
	{
		./UpdateAndroidSdk.cmd
	}
	[string]$builder = "${env:ProgramFiles(x86)}\MSBuild\14.0\Bin\MSBuild.exe"
	[string]$winBuilder = "${env:ProgramFiles(x86)}\MSBuild\14.0\Bin\MSBuild.exe"
	[string]$nuget = "../.nuget/nuget.exe"
	[string]$nugetVerbosity = "normal"
	[string]$dotnetVerbosity = "Information"

	if ( !( Test-Path( "$winBuilder" ) ) )
	{
		$winBuilder = "${env:ProgramFiles}\MSBuild\14.0\Bin\MSBuild.exe"
	}
	if ( !( Test-Path( "$winBuilder" ) ) )
	{
		Write-Error "MSBuild v14 is required."
		exit 1
	}

	if ( !( Test-Path( "${env:ProgramFiles}\dotnet\dotnet.exe" ) ) )
	{
		Write-Error "DotNet CLI is required."
		exit 1
	}
}

[string]$buildConfig = 'Release'
if ( ![String]::IsNullOrWhitespace( $env:CONFIGURATION ) )
{
	$buildConfig = $env:CONFIGURATION
}

[string]$sln = '../MsgPack.sln'
[string]$slnCompat = '../MsgPack.compats.sln'
[string]$slnWindows = '../MsgPack.Windows.sln'
[string]$slnXamarin = '../MsgPack.Xamarin.sln'
[string]$projNetStandard11 = "../src/netstandard/1.1/MsgPack"
[string]$projNetStandard13 = "../src/netstandard/1.3/MsgPack"

$buildOptions = @( '/v:minimal' )
if( $Rebuild )
{
    $buildOptions += '/t:Rebuild'
}

$buildOptions += "/p:Configuration=${buildConfig}"

# Unity
if ( !( Test-Path "./MsgPack-CLI" ) )
{
	New-Item ./MsgPack-CLI -Type Directory | Out-Null
}
else
{
	Remove-Item ./MsgPack-CLI/* -Recurse -Force
}

if ( !( Test-Path "../dist" ) )
{
	New-Item ../dist -Type Directory | Out-Null
}
else
{
	Remove-Item ../dist/* -Recurse -Force
}

if ( ( Test-Path "../bin/Xamarin.iOS10" ) )
{
	Remove-Item ../bin/Xamarin.iOS10 -Recurse
}

if ( !( Test-Path "./MsgPack-CLI/mpu" ) )
{
	New-Item ./MsgPack-CLI/mpu -Type Directory | Out-Null
}

# build
& $nuget restore $sln -Verbosity $nugetVerbosity
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to restore $sln"
	exit $LastExitCode
}

& $builder $sln $buildOptions
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to build $sln"
	exit $LastExitCode
}

& $nuget restore $slnCompat -Verbosity $nugetVerbosity
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to restore $slnCompat"
	exit $LastExitCode
}

& $builder $slnCompat $buildOptions
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to build $slnCompat"
	exit $LastExitCode
}

& $nuget restore $slnWindows -Verbosity $nugetVerbosity
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to restore $slnWindows"
	exit $LastExitCode
}

& $winBuilder $slnWindows $buildOptions
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to build $slnWindows"
	exit $LastExitCode
}

& $nuget restore $slnXamarin -Verbosity $nugetVerbosity
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to restore $slnXamarin"
	exit $LastExitCode
}

& $builder $slnXamarin $buildOptions
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to build $slnXamarin"
	exit $LastExitCode
}

if ( $buildConfig -eq 'Release' )
{
	Copy-Item ../bin/MonoTouch10 ../bin/Xamarin.iOS10 -Recurse
}

dotnet restore $projNetStandard11 -v $dotnetVerbosity
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to restore $projNetStandard11"
	exit $LastExitCode
}

dotnet build $projNetStandard11 -o ../bin/netstandard1.1 -f netstandard11 -c $buildConfig
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to build $projNetStandard11"
	exit $LastExitCode
}

dotnet restore $projNetStandard13 -v $dotnetVerbosity
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to restore $projNetStandard13"
	exit $LastExitCode
}

dotnet build $projNetStandard13 -o ../bin/netstandard1.3 -f netstandard13 -c $buildConfig
if ( $LastExitCode -ne 0 )
{
	Write-Error "Failed to build $projNetStandard13"
	exit $LastExitCode
}

if ( $buildConfig -eq 'Release' )
{
	[string]$zipVersion = $env:PackageVersion
	& $nuget pack ../MsgPack.nuspec -Symbols -Version $env:PackageVersion -OutputDirectory ../dist

	Copy-Item ../bin/ ./MsgPack-CLI/ -Recurse -Exclude @("*.vshost.*")
	Copy-Item ../tools/mpu/bin/ ./MsgPack-CLI/mpu/ -Recurse -Exclude @("*.vshost.*")
	[Reflection.Assembly]::LoadWithPartialName( "System.IO.Compression.FileSystem" ) | Out-Null
	# 'latest' should be rewritten with semver manually.
	if ( ( Test-Path "../dist/MsgPack.Cli.${zipVersion}.zip" ) )
	{
		Remove-Item ../dist/MsgPack.Cli.${zipVersion}.zip
	}
	[IO.Compression.ZipFile]::CreateFromDirectory( ( Convert-Path './MsgPack-CLI' ), ( Convert-Path '../dist/' ) + "MsgPack.Cli.${zipVersion}.zip" )
	Remove-Item ./MsgPack-CLI -Recurse -Force

	if ( $env:APPVEYOR -ne "True" )
	{
		Write-Host "Package creation finished. Ensure AssemblyInfo.cs is updated and ./SetFileVersions.ps1 was executed."
	}
}
