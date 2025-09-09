#!/usr/bin/env bash
# Script to initialize and build a new C# project

# Folder name
DIR="1-new_project"

# Remove the folder if it already exists
if [ -d "$DIR" ]; then
  rm -rf "$DIR"
fi

# Build the project
dotnet build "$DIR"