using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Application.Interfaces;
using TwitterClone.Infrastructure.Persistence;
using TwitterClone.Infrastructure.Repositories;

namespace TwitterClone.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'TwitterCloneDb' is missing.");

            // Registers TwitterCloneDbContext as scoped: one context/session per HTTP request.
            services.AddDbContext<TwitterCloneDbContext>(options => options.UseNpgsql(connectionString)); // giving the database provider(postgresSql) & connection string to the DbContext

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITweetRepository, TweetRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRetweetRepository, RetweetRepository>();

            // Singletons because the repositories keep their data in memory temporarily.
            // Switch to scoped when they are backed by a real database (e.g. EF Core DbContext).
           /* services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITweetRepository, TweetRepository>();
            services.AddSingleton<IBookmarkRepository, BookmarkRepository>();
            services.AddSingleton<IFollowRepository, FollowRepository>();
            services.AddSingleton<ILikeRepository, LikeRepository>();
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<INotificationRepository, NotificationRepository>();
            services.AddSingleton<IRetweetRepository, RetweetRepository>();
           */

            return services;
        }
    }
}