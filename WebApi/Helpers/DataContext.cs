// /////////////////////////////////////////////////////////////////////////////
// PLEASE DO NOT RENAME OR REMOVE ANY OF THE CODE BELOW. 
// YOU CAN ADD YOUR CODE TO THIS FILE TO EXTEND THE FEATURES TO USE THEM IN YOUR WORK.
// /////////////////////////////////////////////////////////////////////////////


namespace WebApi.Helpers;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
  public DataContext() { }

  public DataContext(DbContextOptions<DataContext> options)
       : base(options) { }

  public DbSet<Player> Players { get; set; }
  public DbSet<PlayerSkill> PlayerSkills { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);



        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id = 1,
            Skill = "strength",
            Value = 70,
            PlayerId = 1

        });
        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id = 2,
            Skill = "stamina",
            Value = 90,
            PlayerId = 1

        });
        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id = 3,
            Skill = "strength",
            Value = 50,
            PlayerId =2
        });
        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id = 4,
            Skill = "stamina",
            Value = 2,
            PlayerId = 2
        });


        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id = 5,
            Skill = "defense",
            Value = 60,
            PlayerId =3
        });
        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id = 6,
            Skill = "speed",
            Value = 80,
            PlayerId = 3
        });
        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id = 7,
            Skill = "attack",
            Value = 20,
            PlayerId = 4
        });
        modelBuilder.Entity<PlayerSkill>().HasData(new PlayerSkill
        {
            Id =8,
            Skill = "speed",
            Value = 70,
            PlayerId =4
        });
        modelBuilder.Entity<Player>().HasData(new Player
        {
            Position = "midfielder",
            Id = 1,

            Name = "Enang Lawrence"
        });
        modelBuilder.Entity<Player>().HasData(new Player
        {
            Position = "midfielder",
            Id = 2,

            Name = "Banwo Omosan"
        });
        modelBuilder.Entity<Player>().HasData(new Player
        {
            Position = "defender",
            Id = 3,
            Name = "Awase Faustina"
        });
        modelBuilder.Entity<Player>().HasData(new Player
        {
            Position = "forwarder",
            Id = 4,
            Name = "Awase Clara"
        });






    }

}