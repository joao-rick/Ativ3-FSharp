FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app
COPY src/F# ./

ENTRYPOINT ["dotnet", "fsi"]
CMD ["sequencial.fsx", "--run"]
