using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Entities.Enums.User;

namespace Store.DataAccess.Initialization
{
    public static class DataBaseInitialization
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = new[]
            {
                 new ApplicationUser
                {
                    FirstName = "Emma",
                    LastName = "Jones",
                    Email = "emma@domain.com"
                },
                new ApplicationUser
                {
                    FirstName = "Lincoln",
                    LastName = "Smith",
                    Email = "ls@mail.com"
                },
                new ApplicationUser
                {
                    FirstName = "Zoe",
                    LastName = "Wilson",
                    Email = "zoe@mail.com"
                }
            };

            var authors = new[]
            {
                new Author()
                {
                    Id = 1,
                    Name = "Brit Bennett",
                },
                 new Author()
                 {
                     Id = 2,
                     Name = "Brad Thor",
                 }
            };

            var printingEditions = new[]
            {
                new PrintingEdition()
                {
                    Id = 1,
                    Title = "The Vanishing Half: A Novel",
                    Description = "Hardcover – June 2, 2020",
                    Price = 16.2M,
                    IsRemoved = false,
                    Status = Entities.Enums.Order.Status.Paid,
                    Currency = Entities.Enums.PrintingEdition.Currency.USD,
                    Type = Entities.Enums.PrintingEdition.Type.Book,
                },
                new PrintingEdition()
                {
                    Id = 2,
                    Title = "New York Post",
                    Description = "Your source for breaking news",
                    Price = 8M,
                    IsRemoved = true,
                    Status = Entities.Enums.Order.Status.Paid,
                    Currency = Entities.Enums.PrintingEdition.Currency.USD,
                    Type = Entities.Enums.PrintingEdition.Type.Journal,
                } };

            var userRoles = new[]
            {
                new IdentityRole<long>()
                {
                    Id = (long)UserRole.Admin,
                    Name = UserRole.Admin.ToString()
                },
                new IdentityRole<long>()
                {
                    Id = (long)UserRole.Client,
                    Name = UserRole.Client.ToString()
                }
            };

            var authorInPrintingEditions = new[]
            {
                 new AuthorInPrintingEdition()
                {
                    AuthorId = 1,
                    PrintingEditionId = 1,
                    Date = System.DateTime.Today
                }
            };

            var orders = new[]
            {
                new Order
                {
                    Id = 1,
                    Description = "Book order",
                    ApplicationUserId = 1,
                    Date = DateTime.Today.AddDays(-2),
                    PaymentId = 1
                },
                new Order
                {
                    Id = 2,
                    Description = "Journal order",
                    ApplicationUserId = 3,
                    Date = DateTime.Today.AddDays(-5),
                    PaymentId = 2,
                }
            };

            var payments = new[]
            {
                new Payment
                {
                    Id = 1,
                    TransactionId = 1,
                },
                 new Payment
                {
                    Id = 2,
                    TransactionId = 2,
                }
            };

            var orderItems = new[]
            {
                new OrderItem
                {
                    Id = 1,
                    Amount = 2,
                    Currency = Entities.Enums.PrintingEdition.Currency.USD,
                    PrintingEditionId = 1,
                    OrderId = 1,
                    Count = 1
                },
                new OrderItem
                {
                    Id = 2,
                    Amount = 1,
                    Currency = Entities.Enums.PrintingEdition.Currency.USD,
                    PrintingEditionId = 2,
                    OrderId = 2,
                    Count = 1
                }
            };

            modelBuilder.Entity<PrintingEdition>().HasData(printingEditions);

            modelBuilder.Entity<Author>().HasData(authors);

            modelBuilder.Entity<AuthorInPrintingEdition>().HasData(authorInPrintingEditions);

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            modelBuilder.Entity<IdentityRole<long>>().HasData(userRoles);

            modelBuilder.Entity<Order>().HasData(orders);

            modelBuilder.Entity<Payment>().HasData(payments);

            modelBuilder.Entity<OrderItem>().HasData(orderItems);
        }
    }
}
