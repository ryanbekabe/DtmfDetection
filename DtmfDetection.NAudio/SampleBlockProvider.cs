﻿namespace DtmfDetection.NAudio
{
    using global::NAudio.Wave;

    public class SampleBlockProvider
    {
        private readonly ISampleProvider source;

        private readonly int blockSize;

        public SampleBlockProvider(ISampleProvider source, int blockSize)
        {
            this.source = source;
            this.blockSize = blockSize;
            CurrentBlock = new float[blockSize];
        }

        public float[] CurrentBlock { get; }

        public bool ReadNextBlock()
        {
            var bytesRead = source.Read(CurrentBlock, 0, blockSize);
            return bytesRead >= blockSize;
        }
    }
}