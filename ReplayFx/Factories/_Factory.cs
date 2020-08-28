using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReplayFx.Factories
{
    public class _Factory
    {
        public static Frame CreateFrame() { return new Frame(); }
        public static Ball CreateBall() { return new Ball(); }
        public static GameMetadata CreateGameMetadata() { return new GameMetadata(); }
        public static Player CreatePlayer() { return new Player(); }
        public static PlayerStats CreatePlayerStats() { return new PlayerStats(); }
        public static Team CreateTeam() { return new Team(); }
        public static TeamStats CreateTeamStats() { return new TeamStats(); }
        public static _DbContext CreateContext() { return new _DbContext(); }
        public static Obj CreateModel<Obj>(JObject dataObj) { return dataObj.ToObject<Obj>(); }
    }
}
