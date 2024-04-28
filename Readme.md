Starting container for native AOT build using build image: public.ecr.aws/sam/build-dotnet8:latest-arm64.

docker run --name tempLambdaBuildContainer-7b75dcc9-2e14-4381-b5ff-18fedfc1c506 --rm --volume "/Users/tasos/Repositories/aws/Tenants":/tmp/source/ -i -u 501:20 -e DOTNET_CLI_HOME=/tmp/dotnet -e XDG_DATA_HOME=/tmp/xdg public.ecr.aws/sam/build-dotnet8:latest-arm64 dotnet publish "/tmp/source/src/Functions" --output "/tmp/source/src/Functions/bin/Release/net8.0/publish" --configuration "Release" --framework "net8.0" --self-contained true /p:GenerateRuntimeConfigurationFiles=true --runtime linux-arm64 /p:StripSymbols=true' from directory /Users/tasos/Repositories/aws/Tenants