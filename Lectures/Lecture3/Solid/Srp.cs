using System;
using System.Collections.Generic;
using System.Linq;
using static Lecture3.Solid.Srp;

namespace Lecture3.Solid
{
    public class Srp
    {
        public class PlaneMapper
        {
            private readonly IEngineMapper _engineMapper;
            private readonly ILogger _logger;

            public PlaneMapper(IEngineMapper engineMapper, ILogger logger)
            {
                _engineMapper = engineMapper ?? throw new ArgumentNullException(nameof(engineMapper));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public Plane MapFromDto(PlaneDto dto)
            {
                var result = new Plane()
                {
                    DisplayName = dto.DisplayName,
                };

                var engines = new List<Engine>();

                foreach (var engineDto in dto.Engines)
                {
                    var engine = _engineMapper.MapFromDto(engineDto);
                    engines.Add(engine);
                }

                if (!engines.Any())
                {
                    return new Plane();
                }

                result.Engines = engines;

                try
                {
                }
                catch (Exception ex)
                {
                }

                return result;
            }

            public PlaneDto MapFToDto(Plane dto)
            {
                var result = new PlaneDto()
                {
                };

                return result;
            }
        }

        public class Plane
        {
            public IEnumerable<Engine> Engines { get; set; }

            public string DisplayName { get; set; }
        }

        public class PlaneDto
        {
            public IEnumerable<EngineDto> Engines { get; set; }

            public string DisplayName { get; set; }
        }

        public class Engine
        {
            public IEnumerable<Blade> Blades { get; set; }
        }

        public class EngineDto
        {
            public IEnumerable<BladeDto> Blades { get; set; }
        }

        public class Blade
        {
            public string Name { get; set; }

            public string Chemicals { get; set; }

            public bool CreatedFromCarbonFiber { get; set; }
        }

        public class BladeDto
        {
            public string Name { get; set; }

            public string Chemicals { get; set; }

            public bool CreatedFromCarbonFiber { get; set; }
        }
    }

    public interface ILogger
    {
        void LogError(string message);
    }

    public class Logger : ILogger
    {
        public void LogError(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class EngineMapper : IEngineMapper
    {
        public Engine MapFromDto(EngineDto dto)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEngineMapper
    {
        Engine MapFromDto(EngineDto dto);
    }
}