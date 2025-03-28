using Domain.Repo;
using Model.Configurations;
using Model.Entities;

namespace Domain.Interfaces;

public class BenutzerRepository : ARepository<Benutzer>
{
    public BenutzerRepository(BuchContext context) : base(context)
    {
    }
}