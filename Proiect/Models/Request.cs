using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? ChannelId { get; set; }

        public virtual ApplicationUser? User { get; set; }
        public virtual Channel? Channel { get; set; }
    }
}
