﻿using Minio;
using System.Net;

namespace GenAns.Config
{
    public static class ConfigMinio
    {
        public static IServiceCollection AddMinioService(this IServiceCollection services, IConfiguration configuration)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            services.AddMinio(
                configuration.GetSection("MinioCredentials")["Accsess"],
                configuration.GetSection("MinioCredentials")["Secret"]
                );
            services.AddMinio(configureClient => configureClient
            .WithEndpoint(configuration.GetSection("MinioCredentials")["URL"])
            .WithCredentials(
                configuration.GetSection("MinioCredentials")["Accsess"],
                configuration.GetSection("MinioCredentials")["Secret"]
                ));
            return services;
        }
    }
}
