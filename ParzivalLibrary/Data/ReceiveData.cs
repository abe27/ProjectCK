using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class ReceiveData
    {
        public string id {get; set; } //table->uuid('id')->primary();
        public int seq { get; set; }
        public BatchFileData get_batch_id { get; set; } //table->uuid('batch_id')->nullable()->unsigned();
        public TagData get_tag_id { get; set; } //table->uuid('tag_id')->nullable()->unsigned();
        public List<ReceiveDetailData> get_receive_detail { get; set; }
        public DateTime receive_date { get; set; } //table->date('receive_date')->nullable();
        public string receive_no { get; set; } //table->string ('receive_no')->unique();
        public string receive_status { get; set; } //table->enum('receive_status', [0, 1, 2])->nullable()->default(0);
        public decimal receive_plan { get; set; } //table->string ('receive_no')->unique();
        public decimal receive_rec { get; set; } //table->enum('receive_status', [0, 1, 2])->nullable()->default(0);
        public decimal receive_diff { get; set; } //table->enum('receive_status', [0, 1, 2])->nullable()->default(0);
        public bool sync { get; set; } //table->boolean('sync')->nullable()->default(false);
        public bool is_status { get; set; } //$table->boolean('is_status')->nullable()->default(true);
        public DateTime created_at { get; set; } //"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-15T03:51:59.000000Z"
    }

    public class ReceiveDetailData
    {
        public string id { get; set; } //table->uuid('id')->primary();
        public int seq { get; set; }
        public ReceiveData get_receive_id { get; set; } //table->uuid('receive_id')->unsigned();
        public LedgerData get_part_id { get; set; } //table->uuid('part_id')->unsigned();
        public decimal plan_ctn { get; set; } //table->decimal ('plan_ctn', 10, 2)->nullable()->default(0.0);
        public decimal plan_qty { get; set; } //table->decimal ('plan_qty', 10, 2)->nullable()->default(0.0);
        public decimal rec_ctn { get; set; } //table->decimal ('rec_ctn', 10, 2)->nullable()->default(0.0);
        public decimal plan_diff { get; set; } //table->decimal ('plan_qty', 10, 2)->nullable()->default(0.0);
        public bool is_status { get; set; } //$table->boolean('is_status')->nullable()->default(true);
        public DateTime created_at { get; set; } //"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-15T03:51:59.000000Z"
    }

    public class RecEntObj : HttpResponseData
    {
        public List<ReceiveData> data { get; set; }
    }

    public class ReceiveEntResponse
    {
        public bool success { get; set; }
        public RecEntObj data { get; set; }
        public string message { get; set; }
    }

    public class RecDetailObj : HttpResponseData
    {
        public List<ReceiveDetailData> data { get; set; }
    }

    public class ReceiveDetailResponse
    {
        public bool success { get; set; }
        public RecDetailObj data { get; set; }
        public string message { get; set; }
    }
}
