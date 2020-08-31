using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Helpers.Tools
{
    public class FactoryHelper : CarballHelper
    {
        public static Frame CreateNewFrame() { return new Frame(); }
        public static Ball CreateNewBall() { return new Ball(); }
        public static GameMetadata CreateNewMetadata() { return new GameMetadata(); }
        public static Player CreateNewPlayer() { return new Player(); }
        public static PlayerStats CreateNewPlayerStats() { return new PlayerStats(); }
        public static Team CreateNewTeam() { return new Team(); }
        public static TeamStats CreateNewTeamStats() { return new TeamStats(); }
        public static _DbContext CreateNewContext() { return new _DbContext(); }
    }
}
