#!/usr/bin/env bash
# Script to initialize and build a new C# project
DIR="1-new_project"

mkdir -p "$DIR"

dotnet new console -o "$DIR"

dotnet build -o "$DIR"