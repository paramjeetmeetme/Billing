#!/bin/bash

# Start the .NET Core API script

echo "Starting Diabetes Prediction .NET Core API..."

# Check if .NET is available
if ! command -v dotnet &> /dev/null; then
    echo "Error: .NET SDK is not installed"
    echo "Please install .NET SDK from https://dotnet.microsoft.com/download"
    echo "Or use the provided manual installation instructions"
    exit 1
fi

# Navigate to the .NET project directory
cd DiabetesPredictionAPI

# Restore packages
echo "Restoring NuGet packages..."
dotnet restore
if [ $? -ne 0 ]; then
    echo "Error: Failed to restore packages"
    exit 1
fi

# Build the project
echo "Building the project..."
dotnet build --configuration Release
if [ $? -ne 0 ]; then
    echo "Error: Failed to build project"
    exit 1
fi

# Start the application
echo "Starting .NET Core API on port 7000..."
export ASPNETCORE_ENVIRONMENT=Development
export ASPNETCORE_URLS="http://0.0.0.0:7000"

dotnet run

echo ".NET API stopped."