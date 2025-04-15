using Domain.Repo;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Interfaces;

public class BenutzerRepository : ARepository<Benutzer>
{
    public BenutzerRepository(IDbContextFactory<BuchContext> context) : base(context)
    {
    }
}