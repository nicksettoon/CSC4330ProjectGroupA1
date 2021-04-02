
all: # lists this make file
	less ./Makefile

cert: # runs https cert script
	./dotnet-cert-ubuntu	

dev: # triggers docker-compose dev profile
	docker-compose --profile dev --profile support up --build

ci: # triggers docker-compose continuous integration profile
	docker-compose --profile ci up --build

open: # just opens this project in vscode
	code workspace.code-workspace &

mssqlstart: # starts mssql container
	docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=nickisawesome@1' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU9-ubuntu-16.04

sqlconn: # opens shell with access to server inside container
	# run: make ID=CONTAINER_ID sqlconn
	# run: docker ps lists containers and their IDs
	docker exec -it $(ID) /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'nickisawesome@1'