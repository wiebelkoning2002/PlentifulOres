﻿namespace PlentifulOres;

public static class Utils
{
    public static void GenerateTile(ushort id)
    {
        Config config = PlentifulOres.Config;

        bool nearSurface = config.NearSurface;

        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
        int y = WorldGen.genRand.Next(
            minValue: nearSurface ? (int)GenVars.worldSurfaceLow : (int)GenVars.rockLayerLow,
            maxValue: Main.maxTilesY);

        int additionalStr = config.AdditionalStrength;
        int additionalSteps = config.AdditionalSteps;

        WorldGen.TileRunner(x, y,
            strength: WorldGen.genRand.Next(10 + additionalStr, 15 + additionalStr),
            steps: WorldGen.genRand.Next(3 + additionalSteps, 6 + additionalSteps),
            type: id,
            addTile: config.NotOnlyReplaceButAdd,
            speedX: config.SpeedX,
            speedY: config.SpeedY,
            noYChange: config.NoYChange,
            overRide: config.Override_OnlyChangeIfYouKnowWhatYouAreDoing);
    }

    public static void GenerateHardmodeTile(ushort id)
    {
        Config config = PlentifulOres.Config;

        bool nearSurface = config.NearSurface;

        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
        int y = WorldGen.genRand.Next(
            minValue: nearSurface ? (int)GenVars.worldSurfaceLow : (int)GenVars.rockLayerLow,
            maxValue: Main.maxTilesY);

        Tile tile = Framing.GetTileSafely(x, y);

        // Only generate hardmode ores in replace of other ores
        if (tile.HasTile && TileID.Sets.Ore[tile.TileType])
        {
            WorldGen.TileRunner(x, y,
                strength: WorldGen.genRand.Next(15, 20),
                steps: WorldGen.genRand.Next(3, 6),
                type: id,
                addTile: false,
                speedX: config.SpeedX,
                speedY: config.SpeedY,
                noYChange: false,
                overRide: true);
        }
    }
}
