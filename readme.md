# UnzipandAlterXml

This repository contains the source code for a Windows Forms application that simplifies the process of unzipping, modifying, and repackaging Microsoft Dynamics CRM 2011 solution files.

## Features

* Unzips CRM solution files into a temporary directory
* Provides a user-friendly interface to search and replace specific strings within XML files
* Saves the modified XML files
* Repackages the modified files into a new ZIP archive
* Deletes the temporary directory

## Requirements

* Microsoft .NET Framework 4.0 or higher
* ICSharpCode.SharpZipLib library

## Usage

1. Download the source code from the repository.
2. Compile the project using Visual Studio or a similar IDE.
3. Run the application.
4. Select the CRM solution file you want to modify.
5. Enter the search string and replacement string in the provided text boxes.
6. Click the "Modify XML" button to search and replace the specified strings in the XML files.
7. The modified solution file will be saved in the same directory as the original file with a "_new" suffix.

## Contributing

Please feel free to contribute to this project by submitting bug reports, pull requests, or feature requests.

## License

This project is licensed under the MIT License.
