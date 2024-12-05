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
        /*public ApplicationUser? User { get; set; } //doda�am to*/


        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;


        public string? Information { get; set; }

        public string Status { get; set; } = "Oczekiwanie";

        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; } //czy jest wy�wietlane, to ja sama zrobi�am

        // Nawigacja do mechanika
        //public User Mechanic { get; set; } = default!;

        //Nawigacja do samochodu
        /*public Domain.Entities.Car Car { get; set; } = default!;*/
        //LINIJKA WY�EJ MUSI BY� ZAKOMENTOWANA, JE�ELI CO INNEGO CI PRZESTA�O DZIA�A� TO ZNACZY �E TAM POWINNA� U�YWA� REPAIRWITHCARDTO

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } //sama to doda�am

    }
}
