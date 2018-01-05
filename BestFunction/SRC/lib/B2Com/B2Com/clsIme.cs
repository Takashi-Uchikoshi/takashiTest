using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace B2.Com
{
    /// <summary>
    /// IMEコントロールクラス
    /// </summary>
    public class clsIme
    {
        #region 入力モード値
        /// <summary>入力モード値　日本語</summary>
        public const uint IME_CMODE_NATIVE = 0x0001;
        /// <summary>入力モード値　半角英数</summary>
        public const uint IME_CMODE_ALPHANUMERIC = 0x0000;
        /// <summary>入力モード値　日本語</summary>
        public const uint IME_CMODE_JAPANESE = 0x0001;
        /// <summary>入力モード値　カタカナ</summary>
        public const uint IME_CMODE_KATAKANA = 0x0002;
        /// <summary>入力モード値　半角カタカナ</summary>
        public const uint IME_CMODE_LANGUAGE = 0x0003;
        /// <summary>入力モード値　全角</summary>
        public const uint IME_CMODE_FULLSHAPE = 0x0008;
        /// <summary>入力モード値　ローマ字入力</summary>
        public const uint IME_CMODE_ROMAN = 0x0010;
        /// <summary>入力モード値　文字コード入力</summary>
        public const uint IME_CMODE_CHARCODE = 0x0020;
        /// <summary>入力モード値　HANJA変換モード</summary>
        public const uint IME_CMODE_HANJACONVERT = 0x0040;
        /// <summary>入力モード値　ソフトキーボード</summary>
        public const uint IME_CMODE_SOFTKBD = 0x0080;
        /// <summary>入力モード値　変換しない</summary>
        public const uint IME_CMODE_NOCONVERSION = 0x0100;
        /// <summary>入力モード値　EUDC変換モード</summary>
        public const uint IME_CMODE_EUDC = 0x0200;
        /// <summary>入力モード値　</summary>
        public const uint IME_CMODE_SYMBOL = 0x0400;
        /// <summary>入力モード値　</summary>
        public const uint IME_CMODE_FIXED = 0x0800;
        #endregion

        #region 変換モード値
        /// <summary>変換モード値　無変換</summary>
        public const uint IME_SMODE_NONE = 0x0000;
        /// <summary>変換モード値　人名/地名</summary>
        public const uint IME_SMODE_PLAURALCLAUSE = 0x0001;
        /// <summary>変換モード値　単漢字変換する</summary>
        public const uint IME_SMODE_SINGLECONVERT = 0x0002;
        /// <summary>変換モード値　自動モード</summary>
        public const uint IME_SMODE_AUTOMATIC = 0x0004;
        /// <summary>変換モード値　一般</summary>
        public const uint IME_SMODE_PHRASEPREDICT = 0x0008;
        /// <summary>変換モード値　話し言葉</summary>
        public const uint IME_SMODE_CONVERSATION = 0x0010;
        #endregion

        #region API関数
        /// <summary>
        /// IME クラスの既定のウィンドウハンドルを取得します
        /// </summary>
        /// <param name="hWnd">アプリケーションのウィンドウハンドル</param>
        /// <returns>IMEウィンドウハンドル</returns>
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);

        /// <summary>
        /// 指定されたウィンドウに関連付けられている入力コンテキストを取得します
        /// </summary>
        /// <param name="hWnd">関連付けられている入力コンテキストを取得するウィンドウのハンドル</param>
        /// <returns>入力コンテキストのハンドル</returns>
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetContext(IntPtr hWnd);

        /// <summary>
        /// 入力コンテキストを解放します
        /// </summary>
        /// <param name="hWnd">入力コンテキストを取得するために ImmGetContext 関数を呼び出したときに指定したウィンドウハンドル</param>
        /// <param name="hImc">入力コンテキストのハンドル</param>
        /// <returns>true：正常終了 false：エラー</returns>
        [DllImport("imm32.dll")]
        private static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hImc);

        /// <summary>
        /// 現在の変換状態を設定します
        /// </summary>
        /// <param name="hImc">入力コンテキストのハンドル</param>
        /// <param name="fdwConversion">入力モードの値</param>
        /// <param name="fdwSentence">変換モードの値</param>
        /// <returns>true：正常終了 false：エラー</returns>
        [DllImport("imm32.dll")]
        private static extern bool ImmSetConversionStatus(IntPtr hImc, uint fdwConversion, uint fdwSentence);

        /// <summary>
        /// 現在の変換状態を取得しま
        /// </summary>
        /// <param name="hImc">入力コンテキストのハンドル</param>
        /// <param name="fdwConversion">入力モード値</param>
        /// <param name="fdwSentence">変換モードの値</param>
        /// <returns>true：正常終了 false：エラー</returns>
        [DllImport("imm32.dll")]
        private static extern bool ImmGetConversionStatus(IntPtr hImc, ref uint fdwConversion, ref uint fdwSentence);
        #endregion

        /// <summary>
        /// IMEモード設定
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル</param>
        /// <param name="dwConversion">入力モード</param>
        /// <param name="dwSentence">変換モード</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public static bool SetIMEConversionStatus(IntPtr hWnd, uint dwConversion, uint dwSentence)
        {
            IntPtr hImeWnd = ImmGetDefaultIMEWnd(hWnd);
            if(hImeWnd == IntPtr.Zero)
            {
                return false;
            }

            IntPtr hIMC = ImmGetContext(hImeWnd);
            if(hIMC == IntPtr.Zero)
            {
                return false;
            }

            ImmSetConversionStatus(hIMC, dwConversion, dwSentence);

            return ImmReleaseContext(hImeWnd, hIMC);
        }

        /// <summary>
        /// IMEモード取得
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル</param>
        /// <param name="dwConversion">入力モード</param>
        /// <param name="dwSentence">変換モード</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public static bool GetIMEConversionStatus(IntPtr hWnd, ref uint dwConversion, ref uint dwSentence)
        {
            IntPtr hImeWnd = ImmGetDefaultIMEWnd(hWnd);
            if(hImeWnd == IntPtr.Zero)
            {
                return false;
            }

            IntPtr hIMC = ImmGetContext(hImeWnd);
            if(hIMC == IntPtr.Zero)
            {
                return false;
            }

            ImmGetConversionStatus(hIMC, ref dwConversion, ref dwSentence);

            return ImmReleaseContext(hImeWnd, hIMC);
        }
    }}
