#!/usr/bin/env bash
# Script to initialize and build a new C# project

# Folder name
DIR="1-new_project"

# Remove the folder if it already exists
if [ -d "$DIR" ]; then
  rm -rf "$DIR"
fi

# Create a new console project
dotnet new console -o "$DIR"

# Navigate into the project folder
cd "$DIR" || exit

# Restore dependencies
dotnet restore

# Build the project
dotnet build
