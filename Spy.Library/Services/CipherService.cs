using Spy.Library.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Spy.Library.Services
{
    public class CipherService : ICipherService
    {
        private readonly ISpyRepository _spyRepository;

        public CipherService(ISpyRepository spyRepository)
        {
            _spyRepository = spyRepository;
        }

        public Response Decode(string message, string spyName)
        {
            var codeName = _spyRepository.GetCodeName(spyName);

            if (codeName == null)
                return new Response() { Message = $"Bad Data: {spyName} is not found in the Spy Database. ", StatusCode = 400, Success = false };

            var result = DecodeMessage(message, spyName, codeName);

            return result;
        }

        private static Response DecodeMessage(string message, string spyName, int[] codeName)
        {
            var sequentialMatches = 0;
            var codeNameQueue = ConvertToQueue(codeName);

            foreach (var letter in message.ToIntArray())
            {
                if (codeNameQueue.Peek() != letter) continue;
                codeNameQueue.Dequeue();

                sequentialMatches++;
                if (codeNameQueue.Count == 0) break;
            }

            var result = (sequentialMatches == codeName.Count());

            return DecodeMessageResponse(result, spyName);
        }

        private static Response DecodeMessageResponse(bool result, string spyName)
        {
            return new Response()
            {
                Message = (result) ? $"{spyName} is hiding in the message." : $"{spyName} is not hiding in the message.",
                StatusCode = 200,
                Success = result
            };
        }

        private static Queue<int> ConvertToQueue(IEnumerable<int> codeName)
        {
            var codeNameQueue = new Queue<int>();

            foreach (var item in codeName)
            {
                codeNameQueue.Enqueue(item);
            }

            return codeNameQueue;
        }
    }
}