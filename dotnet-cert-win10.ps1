# powershell script for handling self-signed dev certificates needed for the containers

$CERT_PSWD = [guid]::NewGuid()
dotnet dev-certs https -ep %USERPROFILE%/.aspnet/https/Backend.pfx -p CERT_PSWD
dotnet dev-certs https --trust

docker-compose --profile dev --profile support up --build