using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.Application.Car
{
    public class RepairDto
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public string MechanicId { get; set; }
        /*public ApplicationUser? User { get; set; } //doda³am to*/


        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;


        public string? Information { get; set; }

        public string Status { get; set; } = "Oczekiwanie";

        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; } //czy jest wyœwietlane, to ja sama zrobi³am

        // Nawigacja do mechanika
        //public User Mechanic { get; set; } = default!;

        //Nawigacja do samochodu
        /*public Domain.Entities.Car Car { get; set; } = default!;*/
        //LINIJKA WY¯EJ MUSI BYÆ ZAKOMENTOWANA, JE¯ELI CO INNEGO CI PRZESTA£O DZIA£AÆ TO ZNACZY ¯E TAM POWINNAŒ U¯YWAÆ REPAIRWITHCARDTO

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } //sama to doda³am

    }
}
