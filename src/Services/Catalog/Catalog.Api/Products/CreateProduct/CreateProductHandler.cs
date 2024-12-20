﻿using BuildingBlocks.CQRS;
using Catalog.Api.Models;

namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductCommand(string Name , List<string> Category, string Description , string ImageFile , decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from command
           
           

            var product = new Product()
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //save to db


            //return result
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
