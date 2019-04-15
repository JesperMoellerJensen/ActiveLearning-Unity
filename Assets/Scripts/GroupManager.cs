using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class GroupManager
{
	public static List<Group> Groups = new List<Group>();

	public static void AddGroup(Group group)
	{
		Groups.Add(group);
	}

	public static Group GetGroupById(int groupId)
	{
		return Groups.First(g => g.GroupId == groupId);
	}
}
