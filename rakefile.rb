
require 'albacore'

task :default => [:full]
	
task :full => [:msbuild, :mspec]

desc "Starting build"
msbuild do |msb|
	msb.path_to_command = "C:/Windows/Microsoft.NET/Framework/v4.0.21006/MSBuild.exe"
	msb.properties = {
		:Configuration => :Release,
		:OutputPath => :"C:/Development/OpenSource/MaviBlog/Build",
		:WebProjectOutputDir => :"C:/Development/OpenSource/MaviBlog/Build/Dist",
	}
	msb.targets [:Clean, :Build]
	msb.solution = "Source/MaviBlog.sln"
end

desc "Running specs"
mspec do |mspec|
	mspec.path_to_command = "Tools/MSpec/MSpec.exe"
	mspec.assemblies(
		"Build/MaviBlog.Specs.dll",
		"Build/MaviBlog.Specs.Integration.dll"
	)
	mspec.options(
		"--html Build/MSpecResults.html"
	)
end