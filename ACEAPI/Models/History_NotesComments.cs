﻿using System;
using System.Collections.Generic;

namespace ACEAPI.Models
{
    public partial class History_NotesComments
    {
        public long HistoryId { get; set; }
        public int CommentId { get; set; }
        public int LoanId { get; set; }
        public string CommentUser { get; set; }
        public DateTime? CommentTimestamp { get; set; }
        public string WorkflowStage { get; set; }
        public string WorkflowActivity { get; set; }
        public string NoteComment { get; set; }
    }
}
