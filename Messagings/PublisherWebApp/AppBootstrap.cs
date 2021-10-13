﻿using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherWebApp
{
    public static class AppBootstrap
    {
        public static void Preload(this IApplicationBuilder app,IWebHostEnvironment env,IBus bus)
        {
            // you can also create a rabbitmq conneciton here.
            Console.WriteLine("Write preloaded bootstrapping behaviours and actions");
        }
    }
}
