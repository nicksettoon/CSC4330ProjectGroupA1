
cert:
	./dotnet-cert-ubuntu	

ci:
	docker-compose --profile ci up --build

open:
	code workspace.code-workspace