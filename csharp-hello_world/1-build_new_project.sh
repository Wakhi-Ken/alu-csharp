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

# Build the project (no need to cd or restore separately)
dotnet build "$DIR"

