using ForWorkProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForWorkProject.Context.Configuration;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasMany(s => s.Messages)
                .WithOne(s => s.Chat)
                .HasForeignKey(e => e.ChatId)
                .OnDelete(DeleteBehavior.NoAction);
    }
}
