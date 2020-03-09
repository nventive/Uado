dotnet tool install --global XamlStyler.Console --version 3.2001.0
xstyler -r -d "..\..\src"  -c "..\settings.xamlstyler" --loglevel "Debug"
