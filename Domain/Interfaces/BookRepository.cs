using Domain.Repo;
using Model.Configurations;
using Model.Entities;

namespace Domain.Interfaces;

public class BookRepository: ARepository<Buch>
{
    public BookRepository(BuchContext context) : base(context)
    {
    }
}