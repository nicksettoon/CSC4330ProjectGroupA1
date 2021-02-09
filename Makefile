
cert:
	./dotnet-cert-ubuntu	

dev:
	docker-compose --profile dev up --build
ci:
	docker-compose --profile ci up --build

open:
	code workspace.code-workspace