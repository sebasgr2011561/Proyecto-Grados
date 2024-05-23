using System;
using DesignPatters.Models;

namespace DesignPatters.Repository
{
	public interface IBeer
	{
        IEnumerable<Beer> Get();
        Beer Get(int id);
        void Add(Beer data);
        void Delete(int id);
        void Update(Beer data);

        void Save();
    }
}

