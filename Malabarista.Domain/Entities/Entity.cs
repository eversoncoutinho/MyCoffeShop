using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Domain.Entities
{
    public abstract class Entity
        {
            public virtual long Id { get; protected set; } //identificador
                                                           //metodos para verificar a igualdade de objetos
            public override bool Equals(object obj)
            {
                var other = obj as Entity;
                if (ReferenceEquals(other, null))
                    return false;
                if (ReferenceEquals(this, other))
                    return true;
                if (Id == 0 || other.Id == 0)
                    return false;
                return Id == other.Id;
            }
            public static bool operator ==(Entity a, Entity b)
            {
                if (ReferenceEquals(a, null) && ReferenceEquals(a, null))

                    return true;
                if (ReferenceEquals(a, null) || ReferenceEquals(a, null))
                    return false;
                return a.Equals(b);

            }
            public static bool operator !=(Entity a, Entity b)
            {
                return !(a == b);
            }
            public override int GetHashCode()
            {
                return (GetType().ToString() + Id).GetHashCode();
            }
        }
    }

