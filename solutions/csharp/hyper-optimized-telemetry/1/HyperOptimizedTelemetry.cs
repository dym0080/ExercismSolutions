using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];

        // 2-byte positive => ushort
        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            buffer[0] = 0x02;

            byte[] bytes = BitConverter.GetBytes((ushort)reading);
            Array.Copy(bytes, 0, buffer, 1, bytes.Length);
        }

        // 2-byte negative => short
        else if (reading >= short.MinValue && reading < 0)
        {
            buffer[0] = 0xFE;

            byte[] bytes = BitConverter.GetBytes((short)reading);
            Array.Copy(bytes, 0, buffer, 1, bytes.Length);
        }

        // 4-byte signed => int
        else if (reading >= int.MinValue && reading <= int.MaxValue)
        {
            buffer[0] = 0xFC;

            byte[] bytes = BitConverter.GetBytes((int)reading);
            Array.Copy(bytes, 0, buffer, 1, bytes.Length);
        }

        // 4-byte unsigned => uint
        else if (reading >= 0 && reading <= uint.MaxValue)
        {
            buffer[0] = 0x04;

            byte[] bytes = BitConverter.GetBytes((uint)reading);
            Array.Copy(bytes, 0, buffer, 1, bytes.Length);
        }

        // 8-byte signed => long
        else
        {
            buffer[0] = 0xF8;

            byte[] bytes = BitConverter.GetBytes(reading);
            Array.Copy(bytes, 0, buffer, 1, bytes.Length);
        }

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return buffer[0] switch
        {
            0x02 => BitConverter.ToUInt16(buffer, 1),
            0xFE => BitConverter.ToInt16(buffer, 1),
            0xFC => BitConverter.ToInt32(buffer, 1),
            0x04 => BitConverter.ToUInt32(buffer, 1),
            0xF8 => BitConverter.ToInt64(buffer, 1),
            _ => 0
        };
    }
}