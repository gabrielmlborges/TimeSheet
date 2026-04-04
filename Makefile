PROJECT_INFRA = TimeSheet.Infrastructure
PROJECT_API = TimeSheet.API

migration:
	dotnet ef migrations add $(name) --project $(PROJECT_INFRA) --startup-project $(PROJECT_API)

update:
	dotnet ef database update --project $(PROJECT_INFRA) --startup-project $(PROJECT_API)

run:
	dotnet watch run --project $(PROJECT_API)

rollback-migration:
	dotnet ef migrations remove --project $(PROJECT_INFRA) --startup-project $(PROJECT_API)
