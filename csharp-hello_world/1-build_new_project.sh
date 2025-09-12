#!/usr/bin/env bash
# Script to initialize and build a new C# project
DIR="1-new_project"

if [ -d "$DIR" ]; then
  rm -rf "$DIR"
fi
dotnet build -o "$DIR"