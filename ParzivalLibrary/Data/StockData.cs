using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class StockData
    {
    }

    public class CartonData
    { 
        public string id { get; set; } //$table->uuid('id')->primary();
        public ReceiveDetailData get_receive_id { get; set; } //$table->uuid('receive_id')->nullable()->unsigned();
        public UnitData get_unit_id { get; set; } //$table->uuid('unit_id')->unsigned();
        public string lot_no { get; set; } //$table->string ('lot_no');
        public string transfer_no { get; set; } //$table->string ('transfer_no')->nullable();
        public string serial_no { get; set; } //$table->string ('serial_no')->unique();
        public string die_id { get; set; } //$table->string ('die_id')->nullable();
        public string division_id { get; set; } //$table->string ('division_id')->nullable();
        public double qty { get; set; } //$table->double ('qty', 10, 2)->nullable()->default(0);
        public string carton_status { get; set; } //$table->enum('carton_status', [0, 1, 2, 3, 4, 5, 6, 7, 8])->nullable()->default(0);
        public bool sync { get; set; } //$table->boolean('sync')->nullable()->default(false);
        public bool is_status { get; set; } //$table->boolean('is_status')->nullable()->default(true);
        public DateTime created_at { get; set; } //"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-15T03:51:59.000000Z"
    }
}
