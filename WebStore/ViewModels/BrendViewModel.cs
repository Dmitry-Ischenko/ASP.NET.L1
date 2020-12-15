using System;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.ViewModels
{
    public class BrendViewModel : INamedEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
