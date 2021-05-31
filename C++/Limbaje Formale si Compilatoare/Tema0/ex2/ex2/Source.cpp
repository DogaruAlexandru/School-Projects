#include <iostream>
#include <regex>
#include <string>

std::string FindNumberType(const std::string& number)
{
	std::regex natural{ R"([0-9]+)" };
	std::regex intreg{ R"([-+]?[0-9]+)" };
	std::regex real{ R"([-+]?[0-9]+(\.[0-9]+([Ee]-[0-9]+)?)?)" };

	if (std::regex_match(number, natural))
		return " natural";
	if (std::regex_match(number, intreg))
		return " intreg";
	if (std::regex_match(number, real))
		return " real";
	return " nu este numar";
}

int main()
{
	std::cout << "23" << FindNumberType("23") << '\n';
	std::cout << "23.04" << FindNumberType("23.04") << '\n';
	std::cout << "-14" << FindNumberType("-14") << '\n';
	std::cout << "24.345E-10" << FindNumberType("24.345E-10") << '\n';
	std::cout << "2a37" << FindNumberType("2a37") << '\n';
	std::cout << "23.4.5" << FindNumberType("23.4.5") << '\n';
	std::cout << "34E" << FindNumberType("34E") << '\n';
	std::cout << "34-E" << FindNumberType("34-E");
	return 0;
}