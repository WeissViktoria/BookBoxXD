using Domain.Repo;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Interfaces;

public class BookRepository: ARepository<Buch>
{
    public BookRepository(IDbContextFactory<BuchContext> context) : base(context)
    {
    }
}