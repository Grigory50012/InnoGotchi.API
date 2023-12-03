using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.Infrastructure.Repository.Configuration;

public class DataSeeder
{
    private readonly RepositoryContext _repositoryContext;

    public DataSeeder(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;

    public void Seed()
    {
        if (!_repositoryContext.BodyParts.Any())
        {
            _repositoryContext.AddRange(new List<BodyPart>()
            {
                new BodyPart
                {
                    BodyPartId = new Guid("944f6994-cd24-453c-b5b7-6935204bfb36"),
                    Name = "Body",
                    ImageUrl = "body1.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("abbd653d-9680-4a0c-a485-3ec45d083bdc"),
                    Name = "Body",
                    ImageUrl = "body2.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("cccc548f-4e0e-4d81-bf42-d04c18fedbca"),
                    Name = "Body",
                    ImageUrl = "body3.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("df44186a-08cb-454a-95ac-09e98800ef2d"),
                    Name = "Body",
                    ImageUrl = "body4.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("12a069ba-b2c0-41ed-937e-a692c80382bd"),
                    Name = "Body",
                    ImageUrl = "body5.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("1238384b-7b34-4552-905d-cd9a9f467e4f"),
                    Name = "Eyes",
                    ImageUrl = "eyes1.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("74b4f808-699a-4488-b2de-9b2d4b396c77"),
                    Name = "Eyes",
                    ImageUrl = "eyes2.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("c5d6e6d8-a8bd-45f1-bf21-f0225fb7e505"),
                    Name = "Eyes",
                    ImageUrl = "eyes3.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("0c005e01-4116-459a-bdba-02ccfcc028ae"),
                    Name = "Eyes",
                    ImageUrl = "eyes4.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("f6bda2d8-d5dd-47a0-a77c-0dbaff44b18a"),
                    Name = "Eyes",
                    ImageUrl = "eyes5.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("54f39dbf-3c9d-47d7-aef4-c37da00f2050"),
                    Name = "Eyes",
                    ImageUrl = "eyes6.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("7571ae17-cc89-405d-8cfc-26da317519b0"),
                    Name = "Mouth",
                    ImageUrl = "mouth1.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("23886d38-9d49-4b23-9c63-3a1d95bbd56a"),
                    Name = "Mouth",
                    ImageUrl = "mouth2.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("3d4a10be-9217-4ff9-9f7d-456ae9859d5f"),
                    Name = "Mouth",
                    ImageUrl = "mouth3.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("f03a8c14-6e8d-4ab3-a569-d28117fcbc56"),
                    Name = "Mouth",
                    ImageUrl = "mouth4.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("7544cbc5-8277-49e4-87db-71f836fdf2e3"),
                    Name = "Mouth",
                    ImageUrl = "mouth5.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("2fed2577-e95d-4d54-84e3-b1938cab02b0"),
                    Name = "Nose",
                    ImageUrl = "nose1.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("b552a88f-8c93-4ab1-bde0-d40e25323d86"),
                    Name = "Nose",
                    ImageUrl = "nose2.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("3a476d22-c79a-4a31-bbf2-e7ade8836ab7"),
                    Name = "Nose",
                    ImageUrl = "nose3.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("84baae8a-8d2c-4b68-9d43-92927d174f70"),
                    Name = "Nose",
                    ImageUrl = "nose4.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("85883b2e-23af-45e5-8514-c2f490af90a5"),
                    Name = "Nose",
                    ImageUrl = "nose5.svg"
                },
                new BodyPart
                {
                    BodyPartId = new Guid("0915c10a-2988-4ea8-a956-682e49447401"),
                    Name = "Nose",
                    ImageUrl = "nose6.svg"
                }
            });

            _repositoryContext.SaveChanges();
        }

        if (!_repositoryContext.Roles.Any())
        {
            _repositoryContext.Roles.AddRange(new List<IdentityRole<Guid>>()
            {
                new IdentityRole<Guid>
                {
                    Id = new Guid("4ac8240a-8498-4869-bc86-60e5dc982d27"),
                    Name = "User",
                    NormalizedName = "USER"
                }
            });

            _repositoryContext.SaveChanges();
        }
    }
}
