using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LabExerciseWeek12.EmployeeData;

namespace LabExerciseWeek12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Karyawan> karyawan = new List<Karyawan>();

            Menu(karyawan);   
        }

        static void Menu(List<Karyawan> karyawan)
        {
            bool status = true;

            do
            {
                Console.Clear();

                Console.WriteLine("SELAMAT DATANG DI APLIKASI INPUT DATA KARYAWAN PT KENANGAN KITA\n");
                Console.WriteLine("Nomor Menu Aplikasi: ");
                Console.WriteLine("1). Tambah Data\n2). Hapus Data \n3). Tampilkan Data \n4). Keluar");

                Console.WriteLine();

                ifFalseOption:
                string opts;
                Console.Write("Masukkan Pilihan Anda[1-4]: ");
                opts = Console.ReadLine();

                if (opts == "1")
                {
                    AddData(karyawan);
                    BackToMainMenu();
                }
                else if (opts == "2")
                {
                    DeleteData(karyawan);
                    BackToMainMenu();
                }
                else if (opts == "3")
                {
                    ShowData(karyawan);
                    BackToMainMenu();
                }
                else if (opts == "4")
                {
                    Console.WriteLine("Terima Kasih.");
                    Thread.Sleep(2000);
                    status = false;
                }
                else
                {
                    Console.WriteLine("Pilihan tidak ada, silahkan masukkan pilihan yang tersedia.");
                    goto ifFalseOption;
                }
            } 
            while (status);
        }

        static void AddData(List<Karyawan> karyawan)
        {
            Console.Clear();

            Console.WriteLine("+++++ MENU TAMBAH KARYAWAN +++++");
            Console.WriteLine("\nPilih Jenis Karyawan: ");
            Console.WriteLine("1). Karyawan Tetap \n2). Karyawan Harian \n3). Sales");

            ifFalseOption:
            string opts;
            Console.Write("Masukkan Pilihan Anda [1-3]: ");
            opts = Console.ReadLine();

            Console.WriteLine();

            if (opts == "1")
            {
                KaryawanTetap karyawanTetap = new KaryawanTetap();

                Console.WriteLine("Tambah Karyawan Tetap");

                Console.Write("Masukkan NIK \t\t\t: ");
                karyawanTetap.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t\t: ");
                karyawanTetap.Nama = Console.ReadLine();

                Console.Write("Masukkan Gaji Bulanan \t: ");
                karyawanTetap.GajiBulanan = Convert.ToDouble(Console.ReadLine());

                karyawan.Add(karyawanTetap);
            }
            else if (opts == "2")
            {
                KaryawanHarian karyawanHarian = new KaryawanHarian();

                Console.WriteLine("Tambah Karyawan Harian");

                Console.Write("Masukkan NIK \t\t\t: ");
                karyawanHarian.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t\t: ");
                karyawanHarian.Nama = Console.ReadLine();

                Console.Write("Masukkan Upah per Jam \t: ");
                karyawanHarian.UpahPerJam = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan Jam Kerja \t\t: ");
                karyawanHarian.JumlahJamKerja = Convert.ToDouble(Console.ReadLine());

                karyawan.Add(karyawanHarian);
            }
            else if (opts == "3")
            {
                Sales sales = new Sales();

                Console.WriteLine("Tambah sales");

                Console.Write("Masukkan NIK \t\t\t: ");
                sales.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t\t: ");
                sales.Nama = Console.ReadLine();

                Console.Write("Masukkan Jumlah Penjualan \t: ");
                sales.JumlahPenjualan = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan Komisi \t\t: ");
                sales.Komisi = Convert.ToDouble(Console.ReadLine());

                karyawan.Add(sales);
            }
            else
            {
                Console.WriteLine("Pilihan tidak ada, silahkan masukkan lagi");
                goto ifFalseOption;
            }
        }

        static void DeleteData(List<Karyawan> karyawan)
        {
            Console.Clear();

            Console.WriteLine("----- MENU HAPUS KARYAWAN -----");

            bool found = true;

            string nik;
            Console.Write("\nMasukkan NIK Karyawan: ");
            nik = Console.ReadLine();

            for (int i = 0; i < karyawan.Count; i++)
            {
                if (karyawan[i].NIK == nik)
                {
                    karyawan.Remove(karyawan[i]);
                    found = true;
                    break;
                } else
                {
                    found = false;
                }
            }

            if (!found)
            {
                Console.WriteLine("Data dengan NIK = {0} tidak ditemukan", nik);
            }
            else
            {
                Console.WriteLine("Data dengan NIK = {0} berhasil dihapus", nik);
            }
        }

        static void ShowData(List<Karyawan> karyawan)
        {
            Console.Clear();

            Console.WriteLine("DATA MENU KARYAWAN PT KENANGAN KITA");
            Console.WriteLine("==================================================");
            Console.WriteLine(" NO | NIK / NAMA\t\t | Gaji\t\t |");
            Console.WriteLine("==================================================");
            for(int i = 0; i < karyawan.Count; i++) 
            {
                Console.WriteLine(" {0}. | {1} {2} \t\t | {3} \t |", i + 1, karyawan[i].NIK, karyawan[i].Nama, karyawan[i].Gaji());
            }
        }

        static void BackToMainMenu()
        {
            Console.WriteLine("\nSilakan tekan sembarang tombol untuk kembali ke Menu Utama.");
            Console.ReadKey();
        }
    }
}