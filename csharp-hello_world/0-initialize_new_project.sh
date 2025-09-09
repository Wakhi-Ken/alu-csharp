#c

# Script: 0-initialize_new_project.sh
# Initialize a new C# project in folder 0-new_project

# Set project directory
DIR="0-new_project"

# Create project folder if it doesn't exist
mkdir -p "$DIR"

# Initialize a new C# console project
dotnet new console

# dotnet automatically runs restore, so no need to do it manually
echo "C# project initialized in $DIR"