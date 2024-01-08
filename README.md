# GenesisConsulting

# Download
-  git clone https://github.com/paulovbdr/GenesisConsulting.git

# Requirement
- dotnet --version
  install net8.0.

- npm install -g @angular/cli

# Executing
- cd B3\Application
	dotnet restore
	dotnet build
	dotnet run
	swagger: http://localhost:57790/swagger/index.html

- cd B3\App\B3App
	npm install
	npm start

  
 # Test
 - cd B3
 - dotnet test /p:CollectCoverage=true
