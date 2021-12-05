FROM mcr.microsoft.com/dotnet/sdk:6.0.100-rc.2-bullseye-slim-amd64 as build
COPY . /app
WORKDIR /app
ARG Configuration=Release
RUN dotnet build -c $Configuration

FROM mcr.microsoft.com/dotnet/aspnet:6.0.0-rc.2-bullseye-slim-amd64
COPY --from=build /app/day01/bin/Release/net6.0 /app/day01
COPY data /app/data

ENV INPUT_DAY01_01=/app/data/day01/input.txt

COPY run.sh /app
RUN chmod +x /app/run.sh

WORKDIR /app

ENTRYPOINT ["./run.sh"]
