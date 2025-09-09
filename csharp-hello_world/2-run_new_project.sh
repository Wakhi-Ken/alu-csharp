#!/usr/bin/env bash
# Script to initialize and build a new C# project n runs it

# Folder name
DIR="2-new_project"

# Remove the folder if it already exists
if [ -d "$DIR" ]; then
  rm -rf "$DIR"
fi

# Create a new console project
dotnet new console -o "$DIR"

# Build the project
dotnet build "$DIR"

# Runs the proect
dotnet run --project "$DIR"