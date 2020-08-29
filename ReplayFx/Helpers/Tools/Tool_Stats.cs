using Newtonsoft.Json.Linq;
using ReplayFx.Factories;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Helpers
{
    public class Tool_Stats : Tool_Props
    {
        public static ObjTyp AddStats<ObjTyp>(ObjTyp modelObject, JObject jsonObject, List<string> propertyList)
        {
            JObject modelJson = JBot.CreateObject( modelObject);
            foreach (var jsonLabel in propertyList)
            {
                var NetLabel = nameof( jsonLabel);
                if (
                    Tool_Stats.HasProp(NetLabel, modelJson )
                    && Tool_Stats.HasProp( jsonLabel, jsonObject)
                    )
                {
                    var propertyValue = JBot.GetObject( jsonLabel, jsonObject);
                    modelJson[NetLabel] = propertyValue;
                }
            }
            ObjTyp _FinishedData = _Factory.CreateModel<ObjTyp>( modelJson );
            return _FinishedData;
        }


        public static ObjTyp TryAddStat<ObjTyp>( string Prop, ObjTyp modelObj, JObject jsonObj )
        {
            string netProp =  GetNetProp(Prop);
            JObject modelJson = JBot.CreateObject( modelObj );
            if (JBot.HasProp(netProp, modelJson ) && JBot.HasProp(Prop, jsonObj ) )
            {
                modelJson[netProp] = jsonObj[Prop];
            }
            ObjTyp _FinishedData = _Factory.CreateModel<ObjTyp>( modelJson );
            return _FinishedData;
        }


        public static int GetLeaderId(JObject jsonObj )
        {
            string _ConstantKey = ReturnIf( HasProp( _Constants.PartyLeader, jsonObj ),
                                           _Constants.PartyLeader, _Constants.LeaderId );

            JObject keyObj = JBot.GetObject( _ConstantKey, jsonObj );

            return JBot.GetInt( _Constants.Id, keyObj ); ;
        }


        public static int GetPlayerId(JObject playerdata)
        {
            string _ConstantKey = ReturnIf( HasProp(  _Constants.Player, playerdata ),
                                             _Constants.Player, _Constants.PlayerId );

            JObject keyObj = JBot.GetObject( _ConstantKey, playerdata);

            return JBot.GetInt( _Constants.Id, keyObj ); ;
        }

        public static int GetVictimId(JObject playerdata)
        {
            JObject keyObj = JBot.GetObject( _Constants.VictimId, playerdata);

            return JBot.GetInt( _Constants.Id, keyObj );
        }

        public static int GetAttackerId(JObject playerdata)
        {
            JObject keyObj = JBot.GetObject( _Constants.AttackerId, playerdata);
            return JBot.GetInt( _Constants.Id, keyObj );
        }

        
        public static List<string> GetDataHeadProps() { return _HeaderProps; }
        public static List<string> GetPlayerHeadProps() { return _PlayerHeadProps; }
        public static List<string> GetMetadataProps() { return _MetaDataHeadProps; }
        public static List<string> GetStatHeadProps() { return _StatHeadProps; }

        public static List<List<string>> GetFrameProps()
        {
            List<List<string>> PropertySetList = new List<List<string>>();
            PropertySetList.Add(_HitFrameProps);
            PropertySetList.Add(_KickoffFrameProps);
            return PropertySetList;
        }

        public static List<List<string>> GetFrameHeadProps()
        {
            List<List<string>> PropertySetList = new List<List<string>>();
            PropertySetList.Add( _MetaDataFrames );
            PropertySetList.Add( _GameStatFrames );
            PropertySetList.Add( _FrameBooleans );
            return PropertySetList;
        }


        public static List<List<string>> GetStatProps()
        {
            List<List<string>> PropertySetList = new List<List<string>>();
            PropertySetList.Add( _HitCountProps );
            PropertySetList.Add( _BoostProps );
            PropertySetList.Add( _DistanceProps );
            PropertySetList.Add( _PosTendencyProps );
            PropertySetList.Add( _BallCarryProps );
            PropertySetList.Add( _SpeedProps );
            PropertySetList.Add( _PosessionProps );
            PropertySetList.Add( _KickoffProps );
            return PropertySetList;
        }


        public static IT GetPositionProps<IT>(IT destination, JObject source)
        {
            JObject destJson = JObject.FromObject(destination);

            destJson[_Constants.Pos_X] = source[_Constants.Pos_X];
            destJson[_Constants.Pos_Y] = source[_Constants.Pos_Y];
            destJson[_Constants.Pos_Z] = source[_Constants.Pos_Z];

            IT _FinishedData = destJson.ToObject<IT>();
            return _FinishedData;
        }

        private static readonly List<string> _KickoffFrameProps = _Constants.KickoffFrameSet;
        private static readonly List<string> _HitFrameProps = _Constants.HitFrameSet;
        private static readonly List<string> _HeaderProps = _Constants.HeaderKeySet;
        private static readonly List<string> _MetaDataHeadProps = _Constants.MetadataFrameSet;
        private static readonly List<string> _PlayerHeadProps = _Constants.PlayerHeaderSet;
        private static readonly List<string> _MetaDataFrames = _Constants.MetadataFrameSet;
        private static readonly List<string> _GameStatFrames = _Constants.GameStatsFrameSet;
        private static readonly List<string> _FrameBooleans = _Constants.FrameBoolSet;
        private static readonly List<string> _StatHeadProps = _Constants.StatsHeaderSet;
        private static readonly List<string> _HitCountProps = _Constants.HitCountSet;
        private static readonly List<string> _BoostProps = _Constants.BoostSet;
        private static readonly List<string> _DistanceProps = _Constants.DistanceSet;
        private static readonly List<string> _PosTendencyProps = _Constants.TendenciesSet;
        private static readonly List<string> _BallCarryProps = _Constants.BallCarrySet;
        private static readonly List<string> _SpeedProps = _Constants.SpeedSet;
        private static readonly List<string> _PosessionProps = _Constants.PosessionSet;
        private static readonly List<string> _KickoffProps = _Constants.KickoffStatSet;
    }
}
