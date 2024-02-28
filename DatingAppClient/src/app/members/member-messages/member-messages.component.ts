import { Component, Input, OnInit } from '@angular/core';
import { Message } from '../../models/message';

@Component({
  selector: 'app-member-messages',
  templateUrl: './member-messages.component.html',
  styleUrl: './member-messages.component.css',
})
export class MemberMessagesComponent implements OnInit {
  @Input() messages: Message[] = [];
  @Input() username?: string;

  constructor() {}

  ngOnInit(): void {}
}
