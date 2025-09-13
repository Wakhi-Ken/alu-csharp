#!/usr/bin/env bash
DIR="0-new_project"

# Remove the directory if it already exists
if [ -d "$DIR" ]; then
  rm -rf "$DIR"
fi

# Create a new console project
dotnet new console -o "$DIR"